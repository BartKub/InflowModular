using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Domain.ValueObjects;
using Inflow.Modules.Customers.Core.Exceptions;
using Inflow.Shared.Abstractions.Kernel.ValueObjects;

namespace Inflow.Modules.Customers.Core.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public FullName FullName { get; private set; }
        public Address Address { get; private set; }
        public Nationality Nationality { get; private set; }
        public Identity Identity { get; private set; }
        public string Notes { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? VerificationAt { get; private set; }

        private Customer()
        {

        }

        public Customer(Guid id, Email email, DateTime createdAt)
        {
            Id = id;
            Email = email;
            CreatedAt = createdAt;
        }

        public void Complete(Name name, FullName fullName, Address address, Nationality nationality, Identity identity, DateTime completedAt )
        {
            if (!IsActive)
            {
                throw new CustomerNotActiveException(Id);
            }

            if (CompletedAt.HasValue)
            {
                throw new CannotCompleteCustomerException(Id);
            }

            Name = name;
            FullName = fullName;
            Address = address;
            Nationality = nationality;
            Identity = identity;
            CompletedAt = completedAt;
        }

        public void Verify(DateTime verifiedAt)
        {
            if (!IsActive)
            {
                throw new CustomerNotActiveException(Id);
            }

            if (!CompletedAt.HasValue || VerificationAt.HasValue)
            {
                throw new CannotVerifyCustomerException(Id);
            }

            VerificationAt = verifiedAt;
        }

        public void Lock(string notes = null)
        {
            IsActive = false;
            Notes = notes;
        }

        public void UnLock(string notes = null)
        {
            IsActive = true;
            Notes = notes;
        }
    }
}
