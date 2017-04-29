namespace TypeBuilders
{
    using System;
    using System.Dynamic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public class DynamicWrapper : IDynamicMetaObjectProvider
    {
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            var updateLabelType = CallSiteBinder.UpdateLabel;
            throw new NotImplementedException();
        }
    }
}