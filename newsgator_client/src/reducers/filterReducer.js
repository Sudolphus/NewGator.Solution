import sources from './../constants/sources';
import * as a from './../constants/actions';

const initial_state = {
  sources,
  topic: ''
}

const filterReducer = (state = initial_state, action) => {
  const { type, name, topic, author, date, dropdown } = action;
  switch (type) {
    case a.ADD_SOURCE:
      const newSources = [...state.sources, name];
      return Object.assign({}, state, { sources: newSources });
    case a.REMOVE_SOURCE:
      const newSourcesRemove = state.sources.filter(elem => elem !== name);
      return Object.assign({}, state, { sources: newSourcesRemove });
    case a.CHANGE_TOPIC:
      return Object.assign({}, state, { topic });
    case a.CHANGE_AUTHOR:
      return Object.assign({}, state, { author });
    case a.CHANGE_DATE:
      return Object.assign({}, state, { date });
    case a.CHANGE_DROPDOWN:
      return Object.assign({}, state, { dropdown });
    default:
      return state;
  }
}

export default filterReducer;