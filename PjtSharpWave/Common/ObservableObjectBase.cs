using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace PjtSharpWave.Common
{
    public abstract class ObservableObjectBase<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// INotifyPropertyChanged 인터페이스를 구현 합니다.
        /// </summary>
        /// <param name="property">해당 클래스의 프로퍼티</param>
        protected virtual void OnPropertyChanged(Expression<Func<T, object>> property)
        {
            string propertyName = GetPropertyName(property);
            if (string.IsNullOrEmpty(propertyName)) return;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// INotifyPropertyChanged 인터페이스를 구현 합니다.
        /// </summary>
        /// <param name="propertyName">해당 클래스의 프로퍼티명</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            // Null이 아니면 실행 합니다.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 프로퍼티명을 가져 옵니다.
        /// </summary>
        /// <param name="property">프로퍼티</param>
        /// <returns>프로퍼티명</returns>
        private static string GetPropertyName(Expression<Func<T, object>> property)
        {
            if (property == null || property.Body == null) return null;

            var memberExpr = property.Body as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = property.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member.Name;
            }

            return null;
        }
    }
}
