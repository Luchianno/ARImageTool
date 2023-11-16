# AR Image Tool

Tiny Console app for analyzing bunch of Images by ARCore [arcoreimg](https://developers.google.com/ar/develop/augmented-images/arcoreimg) and writing results to CSV file.

### Usage

1) Build it
2) Put the build in the folder of your liking
3) Locate arcoreimg.exe from Android developer tools and copy it to the same folder
4) Create subfolder (name does not matter) and put your images there
6) Run the app
7) results.csv should be generated in main folder

### Gotchas

* App looks only for png, jpg and jpeg extensions. You can easily modify this behaviour
* Resulting CSV file lacks any formtting, maybe I'll change that
* This was hacked together in an hour, but might save somebody else an hour
