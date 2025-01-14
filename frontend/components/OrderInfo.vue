<template>
  <div class="flex-1 mb-6">
    <h2 class="text-xl font-semibold mb-2">Order Information</h2>
    <p class="text-gray-800">
      <span class="font-semibold">Order ID:</span> {{ order.id }}
    </p>
    <p class="text-gray-800">
      <span class="font-semibold">Total Belopp:</span>
      {{ formatPrice(order.totalCost) }} SEK
    </p>
    <p class="text-gray-500 text-sm">
      <span class="font-semibold">Skapad:</span>
      {{ formatDate(order.createdAt) }}
    </p>
    <p class="text-gray-500 text-sm">
      <span class="font-semibold">Skickad:</span>
      {{ formatDate(order.shippedAt) }}
    </p>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { Order } from "~/types";

defineProps<{ order: Order }>();
</script>
