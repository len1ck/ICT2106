//
// ICT2106 Software Design - Timer exercise
//
// A class representing a timer.
//
namespace ICT2106.Models
{
    class Device
    {
        private string status = "Stopped";

        public string getStatus(){
            return status;
        }
        public void setStatus(string state){
            status = state;
        }
    }
}
