﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Behaviors;
using KidChecklist.Model;

namespace KidChecklist.View
{
    public class CheckBoxBehavior : BaseBehavior<CheckBoxView>
    {
        public ChecklistItem Item { get; set; }

        protected override void OnAttachedTo(CheckBoxView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.EndInteraction += CheckBox_EndInteraction;
        }

        protected override void OnDetachingFrom(CheckBoxView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.EndInteraction -= CheckBox_EndInteraction;
        }

        private void CheckBox_EndInteraction(object sender, TouchEventArgs e)
        {
            var isChecked = Item.IsChecked;
            Item.CheckCommand.Execute(!isChecked);
            ((CheckBoxView)sender).Check(Item.IsChecked);
        }
    }
}
