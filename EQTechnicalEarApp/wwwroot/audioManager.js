let audioBuffer;
let audioSource;
let peakingFilter;
let biquadFilter;

function initializePeakingFilter() {
    biquadFilter = audioCtx.createBiquadFilter();
    biquadFilter.type = "peaking";
}

function playAudio(frequency, gain) {
    if (biquadFilter == null) {
        initializePeakingFilter();
    }

    applyPeakingFilter(frequency, gain);

    audioSource = audioCtx.createBufferSource();
    audioSource.buffer = samples["drumloop"];

    audioSource.connect(biquadFilter);
    biquadFilter.connect(audioCtx.destination);
    audioSource.loop = true;
    audioSource.start(0);
}

function stopAudio() {
    audioSource.stop(0);
    audioSource.loop = false;
}

function applyPeakingFilter(frequency, gain) {
    biquadFilter.frequency.value = frequency;
    biquadFilter.gain.value = gain;
}

function toggleEq(frequency, gain) {
    biquadFilter.frequency.value = frequency;
    biquadFilter.gain.value = gain;
}
