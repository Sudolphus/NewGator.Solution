**NEWSGATOR**

<h1>Purpose:</h1>
This is meant to be a news aggregator that is readily accessible through an app light enough to be loaded on a phone. News stories are queried from a variety of sources on the back end, and held in a MySQL database so they can be quiered, filtered, and sorted with a minimum of fuss, and then displayed to the user with a React app.

<h2>Tools</h2>

- C# and .NET for the backend app
- Newtonsoft for making api calls and destructuring the resulting object
- News APIs: New York Times, Washington Post, Associated Press; others with free developer accounts
- MySQL Server and Entity Framework for storing and retrieving data
- React front end

<h2>Stretch Goals</h2>

- Automatic timer function to refresh/cleanup data
- Move database to cloud hosting (Firestore, possibly?)
- Ability to sort, search, filter results
- User accounts with ability to store user preferences
- Security scheme (tokens?)
- Machine learning to preselect stories by learning user interests

<h2>Additional Tools for Stretch Goals</h2>

- .Net task scheduler library
- Database for cloud hosting: Firestore or MongoDB or CouchDb or similar
- A token generator for React apps, token reader for .NET apps
- Identity or similar user account framework
- ML.Net for machine learning