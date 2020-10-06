import React from 'react';
import PropTypes from 'prop-types';
import { withStory } from './../StoryList';
import Article from './../Article';
import Filter from './../Filter';
import sources from './../../constants/sources';
import Button from 'react-bootstrap/Button';

const Results = ({ stories }) => {
  const [showFilters, setShowFilters] = React.useState(false);
  const [sourcesList, setSourcesList] = React.useState(sources);
  const [topic, setTopic] = React.useState(null);
  const show = showFilters ? null : "d-none";
  const handleHideShow = () => {
    setShowFilters(!showFilters);
  }

  const sourceMatch = (sourceName) => {
    const sourceTest = sourcesList.filter(source => sourceName == source);
    if (sourceTest.length > 0) {
      return true;
    }
    return false;
  }

  const getStoryList = (unfilteredList) => {
    let storyList = unfilteredList.filter(articles => sourceMatch(articles.source));
    if (topic != null && topic != '') {
      const search = new RegExp(topic, 'i');
      storyList = storyList.filter(articles => (search.test(articles.title) || search.test(articles.summary)));
    }
    return storyList;
  }

  const storyList = getStoryList(stories);

  return (
    <React.Fragment>
      <h2>Today's Top Stories</h2>
      <Button type='button' variant='accent-orange' className="mb-2" onClick={handleHideShow}>Show Filters</Button>
      <div className={show}>
        <Filter changeSources={setSourcesList} changeTopic={setTopic} />
      </div>
      {storyList.map(story => <Article key={story.articlesId} story={story} />)}
    </React.Fragment>
  )
}

Results.propTypes = {
  stories: PropTypes.array
}

export default withStory(Results);