# Unity webplayer tuio integration demo (unity project)

this is the unity part of this [demo](https://github.com/david-demainlalune/TuioToUnityWebPlayerDemo).


## TuioWebSocketInput a touchscript input provider

*TuioWebSocketInput* a new touchscript Input provider modeled on TuioInput.
This component must imperatively be added to a GameObject called 'TouchScript'. The browser uses this name to pass messages to unity.

## Dependency

*TuioWebSocketInput* uses Json to deserialize the messages from the browser. In this case we use LitJson.

## Note

This is a weekend project. Use with caution : )


## licence

MIT, read, hack, improve