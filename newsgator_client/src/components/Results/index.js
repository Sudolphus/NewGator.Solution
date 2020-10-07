import React from 'react';
import PropTypes from 'prop-types';
import { withStory } from './../StoryList';
import Article from './../Article';
import Filter from './../Filter';
import sources from './../../constants/sources';
import Button from 'react-bootstrap/Button';

const Results = ({ stories, search, error }) => {
  const [showFilters, setShowFilters] = React.useState(false);
  const [sourcesList, setSourcesList] = React.useState(sources);
  const [topic, setTopic] = React.useState(null);
  
  React.useEffect(() => { setTopic(search)}, [search]);

  const show = showFilters ? null : "d-none";
  const handleHideShow = () => {
    setShowFilters(!showFilters);
  }

  const sourceMatch = (sourceName) => {
    // eslint-disable-next-line
    const sourceTest = sourcesList.filter(source => sourceName == source);
    if (sourceTest.length > 0) {
      return true;
    }
    return false;
  }

  const getStoryList = (unfilteredList) => {
    let storyList = unfilteredList.filter(articles => sourceMatch(articles.source));
    //eslint-disable-next-line
    if (topic != null && topic != '') {
      const search = new RegExp(topic, 'i');
      storyList = storyList.filter(articles => (search.test(articles.title) || search.test(articles.summary)));
    }
    return storyList;
  }

  const storyList = stories ? getStoryList(stories) : null;

  return (
    <React.Fragment>
      <h2>Today's Top Stories</h2>
      <Button type='button' variant='accent-orange' className="mb-2" onClick={handleHideShow}>Show Filters</Button>
      <div className={show}>
        <Filter changeSources={setSourcesList} changeTopic={setTopic} />
      </div>
      {error && <p>{error}</p>}
      {(storyList && !error) && storyList.map(story => <Article key={story.articlesId} story={story} />)}
      {(!storyList && !error) && <p>Loading...</p>}
    </React.Fragment>
  )
}

Results.propTypes = {
  stories: PropTypes.array,
  search: PropTypes.string,
  error: PropTypes.string
}

export default withStory(Results);