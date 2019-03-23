# buttonservice
this is a little service idea for the teXXmo IoT button

See https://catalog.azureiotsolutions.com/details?title=teXXmo-IoT-Button&source=home-page&kit=teXXmo-IoT-Button-Starter-Kit

or http://iot-button.eu/ for the hardware, but this should work for any Azure IoT device.

run.csx is the source code for an Azure function that can be triggered by the iot hub. This simple example just forwards the payload of the iot hub message to a HTTP service. 

To set up this service, create an Azure iot hub and a .net Azure function service, then create a new "editable in the portal" c# function based on the iot hub template. Paste the run.csx function code into the editor, change the base url, url path and authentication as need. To test, paste a sample iot hub payload into the test and press "Save and Run".
