using System;

namespace RH.Domain.Generic
{
    public abstract class Entity : DbEntity<Entity>
    {
        protected Entity(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            base.Iniciatize(this);
        }

        public Guid Id { get; set; }
        public string Nome { get; private set; }
    }
}
