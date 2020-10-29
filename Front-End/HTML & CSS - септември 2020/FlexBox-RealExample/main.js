const [container] = document.getElementsByClassName('container');
const alignContentElement = document.getElementById('align-content');

document.addEventListener('change', (event) => {
  event.preventDefault();
  container.style[event.target.getAttribute('id')] = event.target.value;
  alignContentElement.disabled = event.target.getAttribute('id') === 'flex-wrap' && event.target.value === 'nowrap';

  const [className, flexItemProperty] = event.target.getAttribute('id').split(':');
  const [flexItem] = document.getElementsByClassName(className);
  if (flexItem !== undefined)
    changeFlexItemProperty(flexItem, flexItemProperty, event.target.value)
});


function changeFlexItemProperty(item, flexItemProperty, newValue) {
  item.style[flexItemProperty] = flexItemProperty !== 'flex-basis' ? newValue : `${newValue}px`;
  const newTextContent = item.innerHTML.split('<br>')
    .map(el => el.includes(flexItemProperty)
      ? el.split(', ')
        .map(el => el.includes(flexItemProperty) ? `${flexItemProperty}: ${flexItemProperty !== 'flex-basis' ? newValue : `${newValue}px`}` : el)
        .join(', ')
      : el)
    .join('<br>');
  item.innerHTML = newTextContent;
}