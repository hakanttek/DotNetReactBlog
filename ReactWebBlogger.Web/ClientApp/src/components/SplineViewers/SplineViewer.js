import React, { Component } from 'react';

export class SplineViewer extends Component {
  static displayName = SplineViewer.name;

  constructor(props) {
    super(props);
    this.state = {
      isLoading: true, // State to track loading
    };
    this.splineContainer = React.createRef(); // Create a ref
  }

  componentDidMount() {
    // Create a new Spline viewer element
    const splineViewer = document.createElement('spline-viewer');
    splineViewer.setAttribute('loading-anim-type', 'spinner-small-dark');
    splineViewer.setAttribute('url', this.props.url);

    // Append it to the current component
    this.splineContainer.current.appendChild(splineViewer);

    // Set a timer to hide the spinner after 3 seconds
    setTimeout(() => {
      this.setState({ isLoading: false });
    }, 2000);
  }

  componentWillUnmount() {
    // Stop all audio elements
    const audios = document.getElementsByTagName('audio');
    for (let audio of audios) {
      audio.pause();
      audio.currentTime = 0; // Reset playback position
    }
    
    // Proper cleanup of the Spline viewer
    if (this.splineContainer.current && this.splineContainer.current.firstChild) {
      // Perform any additional cleanup or stop any audio if required here

      // Remove the Spline viewer from the DOM
      this.splineContainer.current.removeChild(this.splineContainer.current.firstChild);
    }
  }

  handleLoad = () => {
    this.setState({ isLoading: false });
  };

  render() {
    return (
      <div ref={this.splineContainer}>
        {this.state.isLoading && (
          <div className="d-flex justify-content-center align-items-center">
            <div className="spinner-border text-primary" role="status"></div>
            <span className="sr-only ms-3">Loading...</span>
          </div>
        )}
        {/* Spline viewer will be appended here */}
      </div>
    );
  }
}

export default SplineViewer;