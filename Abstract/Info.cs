using System;
namespace Abstract
{
    static  class Info
    {

        public static void SetValue(object cls, string name, object value)
        {
            var field = cls.GetType().GetField(name);
            if (field is null)
            {
                throw new Exception($"Can't find field {name}");
            }

            try
            {
                var safeValue = Convert.ChangeType(value, field.FieldType);
                field.SetValue(cls, safeValue);
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't set value to field {name}", ex);
            }
        }
    }
}
