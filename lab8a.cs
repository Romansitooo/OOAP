//zavd 5
using System;

//інтерфейс Phone
public interface IPhone
{
    void MakeCall();
}

//клас реалізації Phone
public class BasicPhone : IPhone
{
    public void MakeCall()
    {
        Console.WriteLine("Здійснення дзвінка...");
    }
}

//інтерфейс для відеокамери
public interface IVideoCamera
{
    void MakeVideoCall();
}

//клас реалізації відеокамери
public class VideoCamera : IVideoCamera
{
    public void MakeVideoCall()
    {
        Console.WriteLine("Здійснення відеодзвінка...");
    }
}

//адаптер для використання відеокамери через інтерфейс Phone
public class VideoCameraAdapter : IPhone
{
    private readonly IVideoCamera videoCamera;

    public VideoCameraAdapter(IVideoCamera videoCamera)
    {
        this.videoCamera = videoCamera;
    }

    public void MakeCall()
    {
        videoCamera.MakeVideoCall();
    }
}

class Program
{
    static void Main()
    {
        //використання базового телефону
        IPhone basicPhone = new BasicPhone();
        basicPhone.MakeCall();

        //використання відеокамери через адаптер
        IVideoCamera videoCamera = new VideoCamera();
        IPhone phoneWithVideo = new VideoCameraAdapter(videoCamera);
        phoneWithVideo.MakeCall();
    }
}
