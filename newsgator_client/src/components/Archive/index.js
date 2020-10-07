import React, { useState, useEffect } from 'react';
import Filter from './../Filter';
import Results from './../Results';

const Archive = () => {
  const [error, setError] = useState(null);
  const [source, setSource] = useState(null);
  const [topic, setTopic] = useState(null);
  const [author, setAuthor] = useState(null);
  const [date, setDate] = useState(null);
  const [storyList, setStoryList] = useState(null);

  useEffect(() => {
    async function getStories() {
      try {
        if (!(source || topic || author || date)) {
          setStoryList(null);
          return;
        }
        let queryString = "";
        if (source) {
          queryString += `&source=${source}`;
        }
        if (topic) {
          queryString += `&topic=${topic}`;
        }
        if (author) {
          queryString += `&author=${author}`;
        }
        if (date) {
          const day = (date[8] === '0') ? date.slice(9) : date.slice(8);
          const month = (date[5] === '0') ? date.slice(6, 7) : date.slice(5, 7);
          const year = date.slice(0, 4);
          queryString += `&date=${day}/${month}/${year}`;
        }
        queryString = '?' + queryString.slice(1);
        const response = await fetch(`http://localhost:5000/api/Info${queryString}`);
        const jsonResponse = await response.json();
        setStoryList(jsonResponse);
        setError(null);
      } catch(err) {
        setError(err.message);
      }
    }
    getStories();
  }, [source, topic, author, date]);

  return (
    <React.Fragment>
      <h2>Search The Archives</h2>
      <Filter 
        archiveFilter={true} 
        changeSources={setSource} 
        changeTopic={setTopic}
        changeAuthor={setAuthor}
        changeDate={setDate} />
      {error && <p>{error.message}</p>}
      {(!error && !storyList) && <p>Loading...</p>}
      {storyList && <Results storyList={storyList} />}
    </React.Fragment>
  );
};

export default Archive;