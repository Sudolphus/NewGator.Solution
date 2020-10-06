import React from 'react';
import PropTypes from 'prop-types';
import Card from 'react-bootstrap/Card';

const Article = ({ story }) => (
  <Card key={story.articlesId}>
    <Card.Header>
      <Card.Title>{story.source}</Card.Title>
      <Card.Subtitle>{story.author} - {story.source}</Card.Subtitle>
    </Card.Header>
    <Card.Body>
      <Card.Text>{story.summary}</Card.Text>
    </Card.Body>
    <Card.Footer>
      <a href={story.url}>Link To Full Story</a>
    </Card.Footer>
  </Card>
)

Article.propTypes = {
  story: PropTypes.object
}

export default Article;