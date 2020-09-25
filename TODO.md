1. Remember how C#/.NET works
2. Pick some news apis, get accounts
3. Figure out how they all structure their data, make sure I can grab it
4. Put the relevant data into the SQL Database:
 - Tables for Headlines and the links, second table for topics, third table as a join seems a reasonable start
 - As a stretch goal, table for user accounts, as well as whatever ML.net ends up needing
5. Create custom endpoints for allowing communication between the React app and the C# app
 - Top Stories should probably be the default
 - Endpoint for filtering results (headline and keywords should be reasonable starts)
 - Sorting and Pagination for results
 - Eventually, endpoint for acquiring tokens (?)
6. Some sort of cleanup routine, since I probably don't want to be holding on to infinite data
7. Make the React app
8. React app should be able to query the C# endpoints and then display the data
9. Start by showing off the top stories of the day, with links to the full article
10. Add filtering ability (by topic, by keyword, by headline, by source)
11. Eventually, add user login and user accounts. Firebase probably easiest solution, but Tokens prefered (?)