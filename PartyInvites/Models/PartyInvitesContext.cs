using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class PartyInvitesContext:DbContext
    {
        public PartyInvitesContext(DbContextOptions<PartyInvitesContext> options)
            :base(options)
        {

        }
        public DbSet<GuestResponse> GuestResponses { get; set; }
    }
}
