LanguageRecognitionWithMicrosoftELS
===================================

An experiment to check the effectiveness of the Extended Linguistic Services introduced in Windows 7

Currently uses a hard coded file reference (the Eurovision Song data included), which is expected to contain two columns of CSV data. The first, a text value to run language identification on (in the example data this is a song title). The second, the actual language the text is supposed to contain.

The application gives passes text to the Microsoft Extended Linguistic Service for identification, converts the response to an English friendly language name and compares the results of each row in the input file to its provided language. The result is summarised in the output console at the end.

The results were as follows for the provided data:

Assusming that results where ELS failed to return a language for the text are "wrong". Approximately 50% accuracy.

Assusming that results where ELS failed to return a language for the text are removed from the set. Approximately 75% accuracy.

The 75% accuracy probably better represents the performance, as that value is for examples ELS was confident about its predictions for.
