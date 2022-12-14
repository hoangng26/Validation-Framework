namespace ValidationFramework.Validations
{
    public class ConstraintViolation : IConstraintViolation
    {
        private string _message;
        private Object _value;
        private string _property;
        private bool _valid = true;
        public ConstraintViolation() { }
        public ConstraintViolation(string message, object value, bool valid)
        {
            _message = message;
            _value = value;
            _valid = valid;
        }

        public string getMessage()
        {
            return _message;
        }

        public string getProperty()
        {
            return _property;
        }

        public object getValue()
        {
            return _value;
        }

        public bool isValid()
        {
            return _valid;
        }

        public void setIsValid(bool valid)
        {
            _valid = valid;
        }

        public void setMessage(string message)
        {
            _message = message;
        }

        public void setProperty(string property)
        {
            _property = property;
        }

        public void setValue(object value)
        {
            _value = value;
        }
    }
}
