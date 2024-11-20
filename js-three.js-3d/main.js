// Molter, Gabriel. Adding a 3D model to a website using THREE.JS, https://www.youtube.com/watch?v=lGokKxJ8D2c

// Add an Interactive 3D Model to Your Website // Three.js Tutorial for Beginners
// https://www.youtube.com/watch?v=aOQuuotM-Ww

import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';

const controls = new OrbitControls( camera, renderer.domElement );
const loader = new GLTFLoader();

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera( 75, window.innerWidth / window.innerHeight, 0.1, 1000 );

const renderer = new THREE.WebGLRenderer();
renderer.setSize( window.innerWidth, window.innerHeight );
document.body.appendChild( renderer.domElement );