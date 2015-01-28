using System;
using Xamarin.Forms;
using ResourceAccess;

namespace Notes_Xamarin
{
    public abstract class BaseContentPage : ContentPage
    {
        INoteAccessor _noteAccessor;
        ResourceAccessFactory _factory;

        public INoteAccessor NoteAccessor
        {
            get
            {
                if (_noteAccessor == null)
                {
                    _noteAccessor = ResourceAccessFactory.Create<INoteAccessor>();
                }
                return _noteAccessor;
            }
            set
            {
                _noteAccessor = value;
            }
        }

        public ResourceAccessFactory ResourceAccessFactory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new ResourceAccessFactory();
                }
                return _factory;
            }
            set
            {
                _factory = value;
            }
        }

        public BaseContentPage()
        {
        }
    }
}

