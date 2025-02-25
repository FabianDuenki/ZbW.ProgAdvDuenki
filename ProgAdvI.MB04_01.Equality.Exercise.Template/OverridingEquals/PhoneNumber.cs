using System;

namespace OverridingEquals {
    public class PhoneNumber {
        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }

        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }

        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }

        // TODO: Implement Equals 
        // TODO: Implement == and !=
        // TODO: Implement GetHashCode
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            
            return this.Equals(obj as PhoneNumber);
        }
        public bool Equals(PhoneNumber? other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(this.AreaCode, other.AreaCode)
                && string.Equals(this.Exchange, other.Exchange)
                && string.Equals(this.SubscriberNumber, other.SubscriberNumber);
        }
        public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
        {
            if(ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return left.Equals(right);

        }
        public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AreaCode, Exchange, SubscriberNumber);
        }   
    }
}