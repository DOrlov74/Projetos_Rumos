using System;

namespace Modelo
{
    public abstract class Person
	    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Email { get; set; }
        }
}
