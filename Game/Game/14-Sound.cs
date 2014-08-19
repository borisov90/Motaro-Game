namespace Game
{
    using System;
    using System.Media;

    class Sound
    {
        public static bool isPlayingMusic = true;
        public static bool isPlayingMusicMenu = true;
        public static bool isStartedMusicMenu = false;

        private static SoundPlayer inGameMusic = new SoundPlayer(@"..\..\ExternalFiles\Chrono_Trigger.wav");
        private static SoundPlayer menuMusic = new SoundPlayer(@"..\..\ExternalFiles\DST-XToFly.wav");

        //private static SoundPlayer inGameMusic = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/Chrono_Trigger.wav");
        //private static SoundPlayer menuMusic = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/DST-XToFly.wav");

        public static void StopMenuMusic()
        {
            menuMusic.Stop();
            isPlayingMusicMenu = false;
        }
        public static void PlayIngameMusic()
        {
            inGameMusic.PlayLooping();
        }
        public static void StopIngameMusic()
        {
            inGameMusic.Stop();
        }
        public static void PauseIngameMusic()
        {
            inGameMusic.Stop();
            isPlayingMusic = false;
        }
        public static void PlayMenuMusic()
        {
            menuMusic.PlayLooping();

        }

        private static SoundPlayer go = new SoundPlayer(@"..\..\ExternalFiles\Go.wav");
        private static SoundPlayer one = new SoundPlayer(@"..\..\ExternalFiles\One.wav");
        private static SoundPlayer two = new SoundPlayer(@"..\..\ExternalFiles\Two.wav");
        private static SoundPlayer three = new SoundPlayer(@"..\..\ExternalFiles\Three.wav");

        //private static SoundPlayer one = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/One.wav");
        //private static SoundPlayer two = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/Two.wav");
        //private static SoundPlayer three = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/Three.wav");
        //private static SoundPlayer go = new SoundPlayer(@"https://dl.dropboxusercontent.com/u/57385182/GameSound/Go.wav");

        public static void PlayOne()
        {
            one.Play();
        }
        public static void PlayTwo()
        {
            two.Play();
        }
        public static void PlayThree()
        {
            three.Play();
        }
        public static void PlayGo()
        {
            go.Play();
        }

    }
}
