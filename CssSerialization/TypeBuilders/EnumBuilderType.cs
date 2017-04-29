namespace TypeBuilders
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;

    public class EnumBuilderType
    {
        private object lockup;
        private readonly AppDomain innerDomain;
        private AssemblyBuilder innerAssemblyBuilder;
        private AssemblyName innerAssemblyName;
        private EnumBuilder innerEnumBuilder;
        private ModuleBuilder innerModuleBuilder;
        private string libraryFullname;
        private string[] backupEnumData;

        public EnumBuilderType()
        {
            this.innerDomain = AppDomain.CurrentDomain;
            this.backupEnumData = new string[0];
        }

        internal AssemblyName NewAssemblyName(string name)
        {
            return new AssemblyName(name);
        }

        internal AssemblyBuilder GetDynamicallyAssemblyBuilder(
            AppDomain domain,
            AssemblyName asmName,
            AssemblyBuilderAccess asmBuilderAccess)
        {
            return domain.DefineDynamicAssembly(asmName, asmBuilderAccess);
        }

        internal ModuleBuilder GetDynamicallyModuleBuilder(
            AssemblyBuilder assemblyBuilder,
            string moduleName,
            string libraryName)
        {
            return assemblyBuilder.DefineDynamicModule(moduleName, libraryName);
        }

        public TypeInfo CreateEnumType(
            string assembly,
            string enumName,
            params string[] enumValues)
        {
            var hasChanges = this.CompareCurrentToPreviousData(enumName, enumValues);
            if (hasChanges)
            {
                this.CreateBackupInfoAboutLastType(enumName, enumValues);
            }

            this.CreateModuleBuilder(hasChanges);
            this.CreateEnumBuilder(enumName);
            for (int i = 0; i < enumValues.Length; i++)
            {
                this.innerEnumBuilder.DefineLiteral(enumValues[i], i);
            }

            var enumType = this.innerEnumBuilder.CreateTypeInfo();
            this.SaveAssembly();
            return enumType;
        }

        public FieldBuilder GetUnderlying()
        {
            return this.innerEnumBuilder.UnderlyingField;
        }

        public void CreateNewAssemblyBuilder(string assemblyName)
        {
            this.innerAssemblyName = this.NewAssemblyName(assemblyName);
            this.libraryFullname = $"{innerAssemblyName.Name}.dll";
            this.innerAssemblyBuilder = this.GetDynamicallyAssemblyBuilder(
                    this.innerDomain,
                    this.innerAssemblyName,
                    AssemblyBuilderAccess.RunAndSave);
            //var compilerResult = new CompilerResults(new TempFileCollection());
        }

        private bool CompareCurrentToPreviousData(string enumName, string[] enumValues)
        {
            var newStackupData = new[] { enumName }.Concat(enumValues);
            var areNotEqual = newStackupData
                .Select((v, i) => this.backupEnumData.Length > 0 && this.backupEnumData[i] == v)
                .Any(v => false);
            this.CreateBackupInfoAboutLastType(enumName, enumValues);
            return !areNotEqual;
        }

        private void CreateBackupInfoAboutLastType(
            string enumName,
            string[] enumValues,
            bool hasChange = false)
        {
            if (this.backupEnumData.Length == 0 || hasChange)
            {
                this.backupEnumData = new[] { enumName }
                    .Concat(enumValues)
                    .ToArray();
            }
        }

        private void CreateEnumBuilder(string enumName)
        {
            this.innerEnumBuilder = this.innerModuleBuilder
                .DefineEnum(
                    $"{this.innerAssemblyName.Name}.{enumName}",
                    TypeAttributes.Public,
                    typeof(int));
        }

        private void CreateModuleBuilder(bool hasChanges)
        {
            bool hasInstantiatingForTheFirstTime = string.IsNullOrEmpty(libraryFullname) ||
                this.libraryFullname == null ||
                this.innerAssemblyName == null ||
                this.innerEnumBuilder == null ||
                this.innerDomain == null;

            if (hasChanges || hasInstantiatingForTheFirstTime)
            {
                if (lockup == null)
                {
                    this.lockup = new object();
                    lock (this)
                    {
                        this.innerModuleBuilder = this.GetDynamicallyModuleBuilder(
                            this.innerAssemblyBuilder,
                            this.innerAssemblyName?.Name,
                            this.libraryFullname);
                        this.lockup = null;
                    }
                }
            }
        }

        private void SaveAssembly()
        {
            if (lockup == null)
            {
                this.lockup = new object();
                lock (this)
                {
                    var fullname = this.libraryFullname;
                    this.innerAssemblyBuilder.Save(this.libraryFullname);
                    this.lockup = null;
                }
            }
        }
    }
}