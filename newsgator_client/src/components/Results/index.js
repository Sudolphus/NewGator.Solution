import React from 'react';
import PropTypes from 'prop-types';
import Article from './../Article';

const Results = ({ storyList }) => {
  return (
    <React.Fragment>
      {storyList.map(article => <Article key={article.articlesId} story={article} />)}
    </React.Fragment>
  )
}

Results.propTypes = {
  storyList: PropTypes.array
};

export default Results;