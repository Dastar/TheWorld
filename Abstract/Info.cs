using System;
namespace Abstract
{
    public class Info
    {
        protected Info()
        {
        }

        public void SetValue(string name, object value)
        {
            var field = GetType().GetField(name);
            if (field is null)
            {
                throw new Exception($"Can't find field {name}");
            }

            try
            {
                var safeValue = Convert.ChangeType(value, field.FieldType);
                field.SetValue(this, safeValue);
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't set value to field {name}", ex);
            }
        }
    }
}
