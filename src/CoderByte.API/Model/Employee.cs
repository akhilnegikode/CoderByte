namespace CoderByte.API.Model
{
    public class Employee
    {
        public void Test(int param)
        {
            if (param == 1)
                OpenWindow();
            else if (param == 2)
                CloseWindow();
            else if (param == 1)  // Noncompliant
                MoveWindowToTheBackground();
        }

        private void MoveWindowToTheBackground()
        {
            throw new System.NotImplementedException();
        }

        private void CloseWindow()
        {
            throw new System.NotImplementedException();
        }

        private void OpenWindow()
        {
            throw new System.NotImplementedException();
        }
    }
}
