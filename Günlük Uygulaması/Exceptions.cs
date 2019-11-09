using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Günlük_Uygulaması
{
    class emptySlotException : ApplicationException
    {
        public emptySlotException(string message) : base(message) { }
    }

    class existingUserException : ApplicationException
    {
        public existingUserException(string message) : base(message) { }
    }

    class notExistingUserException : ApplicationException
    {
        public notExistingUserException(string message) : base(message) { }
    }

    class validationErrorException : ApplicationException
    {
        public validationErrorException(string message) : base(message) { }
    }

    class notOnlyLettersException : ApplicationException
    {
        public notOnlyLettersException(string message): base(message) { }
    }

    class alreadyExistingLog : ApplicationException
    {
        public alreadyExistingLog(string message) : base(message) { }
    }
}
