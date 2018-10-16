using System;

namespace dv607workshop2
{
    class Program
    {
        static void Main(string[] args)
        {

            view.MainView mainView = new view.MainView();
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();

            controller.Controller C = new controller.Controller(xmlHandler, mainView);
            C.Start();
        }

    }
}
