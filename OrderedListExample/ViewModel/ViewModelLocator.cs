﻿namespace OrderedListExample.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get {  return new MainViewModel(); }
        }
    }
}