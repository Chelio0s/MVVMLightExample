namespace MVVMLigtAdvanced.Messages
{
    class OpenDialogMessage
    {
        public  string WindowName { get; set; }

        public OpenDialogMessage(string winName)
        {
            WindowName = winName;
        }
    }
}
