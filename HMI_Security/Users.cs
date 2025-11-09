using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Security
{
    [Designer(typeof(TagManagerDesigner)), ToolboxItem(true)]
    [ToolboxBitmap(typeof(Users), "TagManager.png")]

    public partial class Users : Component
    {
        public Users()
        {
            InitializeComponent();
        }

        internal class TagManagerDesigner : ComponentDesigner
        {
            private DesignerActionListCollection actionLists;
            public override DesignerActionListCollection ActionLists
            {
                get
                {
                    if (actionLists == null)
                    {
                        actionLists = new DesignerActionListCollection();
                        actionLists.Add(new UserListItem(this));
                    }
                    return actionLists;
                }
            }
        }

        internal class UserListItem : DesignerActionList
        {
            private Users shape;
            public UserListItem(ComponentDesigner owner)
                : base(owner.Component)
            {
                shape = (Users)owner.Component;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                var items = new DesignerActionItemCollection();
                items.Add(new DesignerActionTextItem("HMI Edition", "HMI Edition"));
                items.Add(new DesignerActionMethodItem(this, "ShowTagBuilderDialog", "User Manager"));
                return items;
            }

            public void ShowTagBuilderDialog()
            {
                frm_User tagBuilderFrm = new frm_User();
                tagBuilderFrm.ShowDialog();
            }
        }
    }
}
