import React from 'react';
import Filter from './../Filter';
import Results from './../Results';

const Archive = () => {
  const [error, setError] = React.useState(null);
  const [source, setSource] = React.useState(null);
  const [topic, setTopic] = React.useState(null);
  const [storyList, setStoryList] = React.useState(null);

  React.useEffect(() => {
    async function getStories() {
      try {
        if (!source && !topic) {
          setStoryList(null);
          return;
        }
        let queryString = "?";
        if (source) {
          queryString += `source=${source}`;
        }
        if (topic) {
          if (source) {
            queryString += `&topic=${topic}`;
          } else {
            queryString += `topic=${topic}`;
          }
        }
        const response = await fetch(`http://localhost:5000/api/Info${queryString}`);
        const jsonResponse = await response.json();
        setStoryList(jsonResponse);
        setError(null);
      } catch(err) {
        setError(err.message);
      }
    }
    getStories();
  }, [source, topic]);

  return (
    <React.Fragment>
      <h2>Search The Archives</h2>
      <Filter archiveFilter={true} changeSources={setSource} changeTopic={setTopic} />
      {error && <p>{error.message}</p>}
      {(!error && !storyList) && <p>Loading...</p>}
      {storyList && <Results storyList={storyList} />}
    </React.Fragment>
  );
};

export default Archive;