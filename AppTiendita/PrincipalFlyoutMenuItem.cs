using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTiendita
{
    public class PrincipalFlyoutMenuItem
    {
        public PrincipalFlyoutMenuItem()
        {
            TargetType = typeof(PrincipalFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}