import sources from './../constants/sources';
import * as a from './../constants/actions';

const initial_state = {
  sources,
  topic: ''
}

const filterReducer = (state = initial_state, action) => {
  const { type, name, topic } = action;
  switch (type) {
    case a.ADD_SOURCE:
      const newSources = [...state.sources, name];
      return Object.assign({}, state, { sources: newSources });
    case a.REMOVE_SOURCE:
      const newSourcesRemove = state.sources.filter(elem => elem !== name);
      return Object.assign({}, state, { sources: newSourcesRemove });
    case a.CHANGE_TOPIC:
      return Object.assign({}, state, { topic });
    default:
      return state;
  }
}

export default filterReducer;