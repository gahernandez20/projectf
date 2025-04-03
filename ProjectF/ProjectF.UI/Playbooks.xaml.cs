using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectF.Core.ViewModels;

namespace ProjectF.UI;

public partial class Playbooks : ContentPage
{
    public Playbooks(PlaybooksViewModel playbooksViewModel)
    {
        InitializeComponent();
        BindingContext = playbooksViewModel;
    }
}