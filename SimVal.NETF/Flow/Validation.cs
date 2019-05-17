using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimVal.NETF.Flow
{
    public sealed class Validation
    {
        private List<Exception> exceptions;

        public IEnumerable<Exception> Exceptions
        {
            get
            {
                return this.exceptions;
            }
        }

        public Validation AddException(Exception ex)
        {
            lock (this.exceptions)
            {
                this.exceptions.Add(ex);
            }

            return this;
        }

        public Validation()
        {
            this.exceptions = new List<Exception>(1); // optimize for only having 1 exception
        }
    }

}
