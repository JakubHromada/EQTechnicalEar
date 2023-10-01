// The audio contex
var audioCtx;

// Buffer array we'll be using to store the samples we load
// Sample buffers can be used like so: samples[key], e.g. samples["piano"]
var samples = [];

// Attempt to retrieve the given sample from the server and store it in the supplied buffer array with the given key
function loadSample(url, key) {
	// Set up the request to retrieve the sample
	var request = new XMLHttpRequest();
	request.open('GET', url, true);													// Use GET for retrieving a resource
	request.responseType = 'arraybuffer';											// Format of retrieved resource (raw array)

	// Asynchronous callback for when the sample has been retrieved
	request.onload = function () {
		// Decode the raw data into a suitable audio buffer
		audioCtx.decodeAudioData(request.response, 									// Source to be decoded (here, the response)
			function (buffer) { samples[key] = buffer; },							// Callback function for successful decoding
			function () { alert("The file " + url + " could not be loaded!"); });	// Callback function for unsuccessful decoding
	}

	// Go ahead and submit the request
	request.send();
}

function loadSamplesIntoBuffer() {
	// Attempt to load samples into the samples buffer array
	audioCtx = new (window.AudioContext || window.webkitAudioContext)();

	loadSample("drumloop.wav", "drumloop");
	loadSample("flute.wav", "flute");
}

