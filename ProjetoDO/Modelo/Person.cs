using System;

namespace Modelo
{
    public abstract class Person
	    {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
            public virtual string City { get; set; }
            public virtual string Email { get; set; }
        }
}
