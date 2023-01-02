using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Seedwork
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private ICollection<INotification> domainEvents;
        public ICollection<INotification> DomainEvents => domainEvents;
        public void AddDomainEents(INotification notification)
        {
            domainEvents ??= new List<INotification>();
            domainEvents.Add(notification);
        }
    }
}
