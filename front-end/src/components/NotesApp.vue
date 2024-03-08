<template>
  <div class="app-container">
    <!-- Sidebar Section -->
    <div class="sidebar">
    <div class="header-content">
      <h1>All Notes</h1>
      <img src="@/assets/write.png" alt="Write Icon" class="icon" @click="saveNote" />
    </div>
    <!-- Note List Section -->
    <div v-for="note in notes" :key="note.id" class="note">
      <span class="note-text" @click="loadNoteContent(note.id)">{{ formatDate(note.createdAt) }}</span>
      <img src="@/assets/bin.png" alt="Del Icon" class="icon" @click="deleteNote(note.id)">
    </div>
    </div>
    <!-- Main Content Section -->
    <div class="main-content">
      <textarea class="note-editor" v-model="noteContent" placeholder="Welcome to Note Taking App! Share your thought here."  @blur="updateNoteIfNeeded"></textarea>
    </div>

  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      noteContent: '',
      notes: [],
      nextId: 1,
      activeNoteId: null
    };
  },
  methods: {
    async saveNote() {
      if (this.noteContent.trim() === '') {
        alert('Note content is empty.');
        return;
      }  
      if (this.activeNoteId) {
        // An active note is selected, update it
        this.updateNote();
        this.noteContent='';
        this.activeNoteId=null;
      } else {
      try {
        const noteToSave = {
          content: this.noteContent,
          createdAt: new Date().toISOString(),
          updatedAt: new Date().toISOString()
        };
        const response = await axios.post('http://localhost:8080/api/Notes', noteToSave);
        this.notes.push({
          id: response.data.id,
          content: this.noteContent,
          createdAt: response.data.createdAt,
          updatedAt: response.data.updatedAt
        });
        this.noteContent='';
        console.log('Note saved:', response.data);
      } catch (error) {
        console.error('Error saving note:', error);
      }
    }
    },
    async deleteNote(id) {
      try {
        await axios.delete(`http://localhost:8080/api/notes/${id}`);
        this.notes = this.notes.filter(note => note.id !== id);
        if (this.activeNoteId === id) {
          this.noteContent = '';
          this.activeNoteId = null;
          this.lastSavedContent = '';
          this.originalContentLength = 0;
        }
        console.log(`Note with id ${id} has been deleted.`);
      } catch (error) {
        console.error('Error deleting the note:', error);
      }
    },
    async loadNoteContent(id) {
      try {
        const response = await axios.get(`http://localhost:8080/api/Notes/${id}`);
        this.noteContent = response.data.content;
        this.activeNoteId = id;
      } catch (error) {
        console.error('Error loading the note:', error);
      }
    },
    updateNoteIfNeeded() {
      // Only update if there is an active note and the content has changed
      if (this.activeNoteId && this.noteContent !== this.lastSavedContent) {
        this.updateNote();
      }
    },
    async updateNote() {
      const noteToUpdate = {
      id: this.activeNoteId,
      content: this.noteContent,
      createdAt: this.notes.find(note => note.id === this.activeNoteId).createdAt, 
      updatedAt: new Date().toISOString(),
    };
    console.log(`Updating note with ID ${this.activeNoteId}:`, noteToUpdate);
      try {
        const response = await axios.put(`http://localhost:8080/api/notes/${this.activeNoteId}`, noteToUpdate);
        if (response.status === 200) {
          this.notes = this.notes.map(note =>
         note.id === this.activeNoteId ? { ...note, ...response.data } : note);
        this.noteContent = ''; // Clear the textarea
        this.activeNoteId = null; // Reset the activeNoteId
        console.log('Note updated:', response.data);
        }
      } catch (error) {
        console.error('Error updating the note:', error.response ? error.response.data : error.message);
      }
    },watch: {
    // This watcher will make sure to update lastSavedContent when noteContent changes
      noteContent(newVal) {
        if (this.activeNoteId) {
          this.lastSavedContent = newVal;
        }
      }  
    },
    formatDate(dateString) {
    const date = new Date(dateString);
    const formattedDate = date.toLocaleDateString('en-US', {
      year: 'numeric', 
      month: 'short', 
      day: 'numeric'
    });
    const formattedTime = date.toLocaleTimeString('en-US', {
      hour: '2-digit', 
      minute: '2-digit',
      hour12: false
    });
    return `${formattedDate} ${formattedTime} `;
  },
    


  }
}
</script>


