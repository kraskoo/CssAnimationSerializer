namespace Interpretators.Expressions
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Expression : IExpression, ICloneable
    {
        private readonly Stack<IExpression> previousNodes;
        private readonly Queue<IExpression> nextNodes;

        protected Expression(IExpression successor = null)
        {
            this.previousNodes = new Stack<IExpression>();
            this.nextNodes = new Queue<IExpression>();
            this.Successor = successor;
        }

        protected IExpression Successor { get; set; }

        protected void AddFirst(IExpression firstNode)
        {
            firstNode.AddSuccessor(
                this.previousNodes.Count == 0 ?
                this :
                this.previousNodes.Peek());

            this.previousNodes.Push(firstNode);
        }

        protected void AddLast(IExpression lastNode)
        {
            if (this.nextNodes.Count == 0)
            {
                this.AddSuccessor(lastNode);
            }
            else
            {
                this.nextNodes.Peek().AddSuccessor(lastNode);
            }

            this.nextNodes.Enqueue(lastNode);
        }

        public void AddSuccessor(IExpression expression)
        {
            if (this.Successor != null)
            {
                throw new ArgumentException(
                    "Current expression already has a successor.");
            }

            this.Successor = expression;
        }

        public bool RemoveSuccessor()
        {
            if (this.Successor != null)
            {
                this.Successor = null;
                return true;
            }

            return false;
        }

        public abstract void Interpret(IContext context);

        protected IEnumerable<IExpression> GetPrevious()
        {
            if (this.previousNodes.Count > 0)
            {
                do
                {
                    yield return this.PullFirst();
                } while (this.previousNodes.Count != 0);
            }
        }

        protected IEnumerable<IExpression> GetNexts()
        {
            if (this.nextNodes.Count > 0)
            {
                do
                {
                    yield return this.GetLast();
                } while (this.nextNodes.Count != 0);
            }
        }

        private IExpression PullFirst()
        {
            if (this.previousNodes.Count > 0)
            {
                var first = this.previousNodes.Pop();
                if (this.previousNodes.Count == 0)
                {
                    first.RemoveSuccessor();
                }
                else
                {
                    this.previousNodes.Peek().RemoveSuccessor();
                }

                return first;
            }

            return null;
        }

        private IExpression GetLast()
        {
            if (this.nextNodes.Count > 0)
            {
                var last = this.nextNodes.Dequeue();

                if (this.nextNodes.Count == 0)
                {
                    this.RemoveSuccessor();
                }
                else
                {
                    this.nextNodes.Peek().RemoveSuccessor();
                }

                return last;
            }

            return null;
        }

        public object Clone()
        {
            return (Expression)this.MemberwiseClone();
        }
    }
}