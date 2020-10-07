import * as a from './../constants/actions';

export const addSource = (name) => ({
  type: a.ADD_SOURCE,
  name
});

export const removeSource = (name) => ({
  type: a.REMOVE_SOURCE,
  name
});

export const changeTopic = (topic) => ({
  type: a.CHANGE_TOPIC,
  topic
})

export const changeAuthor = (author) => ({
  type: a.CHANGE_AUTHOR,
  author
})