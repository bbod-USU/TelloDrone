namespace Tello_Drone
{
    public interface IDroneCommands
    {
        void Forward(int x);
        void Reverse(int x);
        void Up(int z);
        void Down(int z);
        void Left(int y);
        void Right(int y);
        bool Command();
        bool InitialTakeOff();
        void TakeOff();
        void Land();
        void RotateClockWise(int r);

    }
}