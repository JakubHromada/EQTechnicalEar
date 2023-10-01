using Android.Media;

namespace EQTechnicalEarApp.Platforms
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private MediaPlayer _player;

        public void PlayAudio()
        {
            var context = Platform.CurrentActivity;

            if (_player == null)
            {
                _player = MediaPlayer.Create(context, Resource.Raw.sampleandroid);
                _player.Looping = true;
                _player.Prepared += (s, e) =>
                {
                    // Start the player once it's prepared
                    _player.Start();
                };

                // If the audio resource isn't large, it may not require asynchronous preparation.
                // In that case, we can directly start the player and set up the equalizer.
                if (!_player.IsPlaying)
                {
                    _player.Start();
                }
            }
        }

        public void StopAudio()
        {
            _player?.Stop();
            _player?.Release();
            _player = null;
        }
    }
}
