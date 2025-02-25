namespace OverridingEquals {
    public class Employee {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Equals(Employee? other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;

            return string.Equals(FirstName, other.FirstName)
                && string.Equals(LastName, other.LastName);
        }
        public override bool Equals(object? obj)
        {
            if(ReferenceEquals (null, obj)) return false;

            return Equals (obj as Employee);
        }
        public static bool operator ==(Employee left, Employee right)
        {
            if (ReferenceEquals(null, left) || ReferenceEquals(right, null)) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Employee left, Employee right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}