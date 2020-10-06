import React from 'react';
import PropTypes from 'prop-types';
import { withStory } from './../StoryList';
import Article from './../Article';
import Filter from './../Filter';
import Button from 'react-bootstrap/Button';

const Results = ({ stories }) => {
  const [showFilters, setShowFilters] = React.useState(false);
  const show = showFilters ? null : "d-none";
  const handleHideShow = () => {
    setShowFilters(!showFilters);
  }

  return <React.Fragment>
    <h2>Today's Top Stories</h2>
    <Button type='button' variant='accent-orange' className="mb-2" onClick={handleHideShow}>Show Filters</Button>
    <div className={show}>
      <Filter />
    </div>
    {stories.map(story => <Article key={story.articlesId} story={story} />)}
  </React.Fragment>
}

Results.propTypes = {
  stories: PropTypes.array
}

export default withStory(Results);