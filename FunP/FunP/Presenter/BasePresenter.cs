using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    abstract class BasePresenter
    {
        protected IView view;

        public void AttachView(IView view)
        {
            this.view = view;
        }
    }
}
