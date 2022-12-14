namespace ValidationFramework.Validations
{
    public interface IConstraintViolation
    {
        string getMessage();
        void setMessage(string message);
        Object getValue();
        void setValue(Object value);
        string getProperty();
        void setProperty(string property);
        bool isValid();
        void setIsValid(bool valid);
    }
}
