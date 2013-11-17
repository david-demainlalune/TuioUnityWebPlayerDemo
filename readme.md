# Unity webplayer tuio integration demo (unity project)

This repo holds the Unity sources for this [demo](https://github.com/david-demainlalune/TuioToUnityWebPlayerDemo). 

The Unity project receives Tuio messages from the browser. They are handled by **TuioWebSocketInput** a [TouchScript](https://github.com/InteractiveLab/TouchScript) input provider


## TuioWebSocketInput

**TuioWebSocketInput** is a new touchscript Input provider modeled on TuioInput.
This component must imperatively be added to a GameObject called 'TouchScript'. The browser uses this name to pass messages to unity.

## Dependency

**TuioWebSocketInput** uses Json to deserialize the messages from the browser. In this case we use LitJson.

## Note

This is a weekend project. Use with caution : )


## licence

MIT, read, hack, improve