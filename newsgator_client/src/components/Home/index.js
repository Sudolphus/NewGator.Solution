import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { withStory } from './../StoryList';
import Filter from './../Filter';
import Results from './../Results';
import sources from './../../constants/sources';

const Home = ({ stories, search, error }) => {
  const [sourcesList, setSourcesList] = useState(sources);
  const [topic, setTopic] = useState(null);
  const [author, setAuthor] = useState(null);
  
  React.useEffect(() => { setTopic(search)}, [search]);

  const sourceMatch = (sourceName) => {
    // eslint-disable-next-line
    const sourceTest = sourcesList.filter(source => sourceName == source);
    if (sourceTest.length > 0) {
      return true;
    }
    return false;
  }

  const getStoryList = (unfilteredList) => {
    const topicSearch = topic ? new RegExp(topic, 'i') : /./;
    const authorSearch = author ? new RegExp(author, 'i') : /./;
    const storyList = unfilteredList.filter(articles => sourceMatch(articles.source) && (topicSearch.test(articles.title) || topicSearch.test(articles.summary)) && authorSearch.test(articles.author));
    return storyList;
  }

  const storyList = stories ? getStoryList(stories) : null;

  return (
    <React.Fragment>
      <h2>Today's Top Stories</h2>
      <Filter 
        archiveFilter={false} 
        changeSources={setSourcesList} 
        changeTopic={setTopic} 
        changeAuthor={setAuthor} />
      {error && <p>{error}</p>}
      {(!storyList && !error) && <p>Loading...</p>}
      {(storyList && !error) && <Results storyList={storyList} />}
    </React.Fragment>
  )
}

Home.propTypes = {
  stories: PropTypes.array,
  search: PropTypes.string,
  error: PropTypes.string
}

export default withStory(Home);